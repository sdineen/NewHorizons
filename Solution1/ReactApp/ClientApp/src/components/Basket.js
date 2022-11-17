import React from 'react';

export default function Basket(props) {
    //properties
    const order = props.order;
    const handlePurchaseClick = props.handlePurchaseClick;
    const handleRemoveClick = props.handleRemoveClick;

    if (order == null || order.lineItems == null 
         || order.lineItems.length === 0) {
        return null;
    }

    const rows = order.lineItems
        .map(lineItem =>
            <tr key={lineItem.id}>
                <td>{lineItem.product.name}</td>
                <td>{lineItem.quantity}</td>
                <td>
                    <input type="submit"
                        value="Remove"
                        onClick={handleRemoveClick}
                        id={lineItem.product.id}
                        className="btn btn-secondary" />
                </td>
            </tr>);

    return (
        <div>
            <h5>Order id: {order.orderId}</h5>
            <input
                onClick={handlePurchaseClick}
                type="submit"
                value="Purchase"
                className="btn btn-primary" />
            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Quantity</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        </div>
    );
}




/*
table rows can be factored into a separate component
const rows = order.lineItems
    .map(lineItem =>
        <tr key={lineItem.id}>
            <td>{lineItem.product.name}</td>
            <td>{lineItem.quantity}</td>
            <td>
                <input type="submit"
                    value="Remove"
                    onClick={handleRemoveClick}
                    id={lineItem.product.id}
                    className="btn btn-secondary" />
            </td>
        </tr>);

const rows = order.lineItems
    .map(lineItem =>
        <BasketRow
            key={lineItem.id}
            lineItem={lineItem}
            handleRemoveClick={handleRemoveClick} />);


function BasketRow(props) {
    const lineItem = props.lineItem;

    return <tr key={lineItem.id}>
        <td>{lineItem.product.name}</td>
        <td>{lineItem.quantity}</td>
        <td>
            <input type="submit"
                value="Remove"
                onClick={props.handleRemoveClick}
                id={lineItem.product.id}
                className="btn btn-secondary" />
        </td>
    </tr>
}
*/