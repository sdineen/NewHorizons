using ClassLibrary.Entity;
using ClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ClassLibrary.Service
{
    public class EcommerceService : IEcommerceService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IProductRepositoryAsync productRepository;
        private readonly IOrderRepositoryAsync orderRepository;

        public EcommerceService(IAccountRepository accountRepository, IProductRepositoryAsync productRepository, IOrderRepositoryAsync orderRepository)
        {
            this.accountRepository = accountRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        //used by ReactApp
        public Account SelectAuthenticatedAccount(string username, string password)
        {
            Account account = accountRepository.SelectById(username);
            if (account.IsAuthenticated(password))
            {
                return account;
            }
            throw new AuthenticationException();
        }

        public async Task<ICollection<Product>> SelectProductsAsync(string partOfName = null)
        {
            ICollection<Product> products = partOfName == null ?
                await productRepository.SelectAllAsync() :
                await productRepository.SelectByNameAsync(partOfName);

            return products;
        }

        public async Task<Order> AddProductToOrderAsync(string productId, string accountId)
        {
            Product product = await productRepository.SelectByIdAsync(productId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product not found");
            }

            Account account = accountRepository.SelectById(accountId);
            if (account == null)
            {
                throw new InvalidOperationException($"user {accountId} is not registered");
            }

            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);
            if (order == null)
            {
                order = new Order { AccountId = accountId };
                await orderRepository.CreateAsync(order);
            }

            order.AddProduct(product, 1);
            await orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<Order> SelectProvisionalOrderAsync(string accountId)
        {
            Account account = accountRepository.SelectById(accountId);
            if (account == null)
            {
                throw new InvalidOperationException($"user {accountId} is not registered");
            }

            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);

            if (order == null)
            {
                order = new Order { AccountId = accountId };
                await orderRepository.CreateAsync(order);
            }
            return order;
        }

        public async Task<bool> ConfirmOrderAsync(string accountId)
        {
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);
            if (order == null)
            {
                throw new InvalidOperationException($"Provisional order for account {accountId} not found");
            }
            order.OrderStatus = OrderStatus.Confirmed;
            return await orderRepository.UpdateAsync(order);
        }

        public async Task<Order> RemoveProductFromOrderAsync(string productId, string accountId)
        {
            Product product = await productRepository.SelectByIdAsync(productId);
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);
            if(product==null || order == null)
            {
                throw new InvalidOperationException("product or order not found");
            }
            bool removed = order.RemoveLineItem(product);
            await orderRepository.UpdateAsync(order);
            return order;
        }
        public async Task<bool> CreateProductAsync(Product product)
        {
            return await productRepository.CreateAsync(product);
        }

        public async Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId)
        {
            return await orderRepository.SelectOrdersByAccountIdAsync(accountId);
        }

        public async Task<Order> SelectOrderAsync(int orderId)
        {
            return await orderRepository.SelectByOrderIdAsync(orderId);
        }

        public bool CreateAccount(Account account)
        {
            return accountRepository.Create(account);
        }
    }
}
