import React, { useState, useEffect } from 'react';
import ProductTableRow from './ProductTableRow';
import axios from 'axios';//https://github.com/axios/axios

export default function ProductTable(props) {
    //properties
    const url = props.url + '/api/product/';
    //const handleSelect  = props.handleSelect;

    //state
    const [searchText, setSearchText] = useState('');
    const [products, setProducts] = useState([]);

    //event handler
    const handleTextChange = event => setSearchText(event.target.value);
    
    //local variables
    const tableRows = products.map(product =>
        <ProductTableRow handleSelect={props.handleSelect}  
                         key={product.id} product={product} />);

    //Do after render. will repeat if searchText dependency changes.
    //Setting product state cause re-render.
    //Does not require authentication
    useEffect(() => {
        console.log('useEffect: get products');
         axios.get(url +searchText )
            .then(response => setProducts(response.data))
            .catch(error => console.log(error));
    }, [searchText]);

    return (
        <div>
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
