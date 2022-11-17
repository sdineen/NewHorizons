import React, { useState } from 'react';


export default function SearchableList() {

    const [searchText, setSearchText] = useState('');

    const tableRows = products.filter(product => product.name.includes(searchText)).map(product =>
        <tr>
            <td>{product.id}</td>
            <td>{product.name}</td>
            <td>{product.costPrice}</td>
            <td>{product.retailPrice}</td>
        </tr>);

    const handleTextChange = event => setSearchText(event.target.value);


    return (
        <div className="container">
            <input
                type="text"
                placeholder="Search..."
                value={searchText}
                //link onChange attribute to method with signature "onChange(event):void"
                onChange={handleTextChange}
                className="form-control"
            />
            <table className="table">
                <tbody>{tableRows}</tbody>
            </table>
        </div>
    );

}

const products = [{ "id": "p2", "name": "Knife", "costPrice": 0.6, "retailPrice": 1.2, "rowVersion": "AAAAAAAAZgI=" }, { "id": "p3", "name": "Fork", "costPrice": 0.55, "retailPrice": 1.1, "rowVersion": "AAAAAAAAZgM=" }, { "id": "p4", "name": "Spaghetti", "costPrice": 0.44, "retailPrice": 0.88, "rowVersion": "AAAAAAAAZgQ=" }, { "id": "p5", "name": "Cheddar Cheese", "costPrice": 0.67, "retailPrice": 1.34, "rowVersion": "AAAAAAAAZgU=" }, { "id": "p6", "name": "Bean bag", "costPrice": 11.2, "retailPrice": 20.4, "rowVersion": "AAAAAAAAZgY=" }, { "id": "p7", "name": "Bookcase", "costPrice": 32, "retailPrice": 64, "rowVersion": "AAAAAAAAZgc=" }, { "id": "p8", "name": "Table", "costPrice": 70, "retailPrice": 140, "rowVersion": "AAAAAAAAZgg=" }, { "id": "p9", "name": "Chair", "costPrice": 60, "retailPrice": 120, "rowVersion": "AAAAAAAAZgk=" }];
