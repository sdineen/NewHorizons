import React, { useState, useEffect } from 'react';
import axios from 'axios';//https://github.com/axios/axios
import ProductTable from './ProductTable';
import Basket from './Basket';
import LoginForm from './LoginForm';
import Header from './Header';

export default function App() {
    //debugger;

    const url = 'https://sdineen.uk';
    //const url = 'https://localhost:44369';
    //state
    const [order, setOrder] = useState({});
    const [user, setUser] = useState({});

    //handles submit button on login form
    const handleLoginSubmit = user => setUser(user);

    //event handler for select button sends post request containing selected product id and username
    const handleSelect = event => addProductToOrder(event.target.id);

    //event handler for remove button in basket sends post request 
    //containing selected product id and username
    const handleRemoveClick = event => removeProductFromOrder(event.target.id);

    //event handler for purchase button sends put request
    const handlePurchaseClick = event => purchase();

    //PUT request to OrderController
    async function purchase() {
        if (user.isAuthenticated) {
            try {
                console.log('handlePurchaseClick');
                const response = await axios({
                    method: 'put',
                    url: url + '/api/order/'+ user.username,
                    headers: { 'Authorization': 'Bearer ' + user.token }
                });
                setOrder(null); //changing state causes a re-render
                console.log('purchase ' + response.status);
            }
            catch (error) {
                console.error(error);
            }
        }
    }

    async function removeProductFromOrder(id) {
        try {
            const response = await axios({
                method: 'post',
                url: url + '/api/order/remove',
                data: { productId: id, username: user.username },
                headers: { 'Authorization': 'Bearer ' + user.token }
            });
            setOrder(response.data); //changing state causes a re-render of this component and child components
            console.log(response.data);
        }
        catch (error) {
            console.error(error);
        }
    }


    //do after render. 
    useEffect(() => {
        if (user.isAuthenticated) {
            getBasket();
        }
    }, [user]);

    async function getBasket() {
        try {
            const response = await axios({
                method: 'get',
                url: url + '/api/order/' + user.username,
                headers: { 'Authorization': 'Bearer ' + user.token }
            });
            setOrder(response.data); //changing state causes a re-render of this component and child components
            console.log(response.data);
        }
        catch (error) {
            console.error(error);
        }
    }

    async function addProductToOrder(id) {
        try {
            const response = await axios({
                method: 'post',
                url: url + '/api/order',
                data: { productId: id, username: user.username },
                headers: { 'Authorization': 'Bearer ' + user.token }
            });
            //changing state causes a re-render 
            setOrder(response.data);
            console.log(response.data);
        }
        catch (error) {
            console.error(error);
        }
    }

    const loginForm = user.isAuthenticated ? <div /> :
        <LoginForm url={url} handleLoginSubmit={handleLoginSubmit} />

    return <div className="container">
        <Header user={user} />
        {loginForm}
        <Basket order={order} handlePurchaseClick={handlePurchaseClick}
            handleRemoveClick={handleRemoveClick} />
        <ProductTable url={url} handleSelect={handleSelect} />
    </div>;
}

const productArray = [{ "id": "p2", "name": "Knife", "costPrice": 0.6, "retailPrice": 1.2, "rowVersion": "AAAAAAAAZgI=" }, { "id": "p3", "name": "Fork", "costPrice": 0.55, "retailPrice": 1.1, "rowVersion": "AAAAAAAAZgM=" }, { "id": "p4", "name": "Spaghetti", "costPrice": 0.44, "retailPrice": 0.88, "rowVersion": "AAAAAAAAZgQ=" }, { "id": "p5", "name": "Cheddar Cheese", "costPrice": 0.67, "retailPrice": 1.34, "rowVersion": "AAAAAAAAZgU=" }, { "id": "p6", "name": "Bean bag", "costPrice": 11.2, "retailPrice": 20.4, "rowVersion": "AAAAAAAAZgY=" }, { "id": "p7", "name": "Bookcase", "costPrice": 32, "retailPrice": 64, "rowVersion": "AAAAAAAAZgc=" }, { "id": "p8", "name": "Table", "costPrice": 70, "retailPrice": 140, "rowVersion": "AAAAAAAAZgg=" }, { "id": "p9", "name": "Chair", "costPrice": 60, "retailPrice": 120, "rowVersion": "AAAAAAAAZgk=" }];

const orderObject = {
    "orderId": 1004,
    "date": "2020-04-09T17:59:29.5805097",
    "orderStatus": 0,
    "account": {
        "id": "acc1",
        "name": "John Smith",
        "password": "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08"
    },
    "accountId": "acc1",
    "lineItems": [
        {
            "id": 1010,
            "quantity": 1,
            "product": {
                "id": "p3",
                "name": "Fork",
                "costPrice": 0.55,
                "retailPrice": 1.1,
                "rowVersion": "AAAAAAAAZgM="
            },
            "productId": "p3"
        },
        {
            "id": 1011,
            "quantity": 2,
            "product": {
                "id": "p2",
                "name": "Knife",
                "costPrice": 0.6,
                "retailPrice": 1.2,
                "rowVersion": "AAAAAAAAZgI="
            },
            "productId": "p2"
        }
    ]
};