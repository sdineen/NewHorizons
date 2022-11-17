import React from 'react';

export default function ProductTableRow(props) {
    const product = props.product;
    const handleSelect = props.handleSelect;

    return (
        <tr>
            <td>{product.id}</td>
            <td>{product.name}</td>
            <td>{format(product.costPrice)}</td>
            <td>{format(product.retailPrice)}</td>
            
            <td>
                <input type="submit"
                    value="Select"
                    onClick={handleSelect}
                    id={product.id}
                    className="btn btn-secondary" />
            </td>
        </tr>
    );    
}

function format(value){
    let options = { style: "currency", currency: "GBP" };
    let formatter = new Intl.NumberFormat("en-GB", options);
    return formatter.format(value)
}
//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/NumberFormat