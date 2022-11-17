import React from 'react';
import Clock from './Clock';
export default function Header(props) {
    const user = props.user;
    let greeting;

    if (user.name == null) {
        greeting = <h4>Online Store <Clock /></h4>; 
    }
    else {
        greeting = <h4>Welcome {user.name} <Clock /></h4>;
    }
    return <div>{greeting}<hr /></div>;
}

//let spinner = <div className={isLoading ? "spinner-border text-warning" : ""} />;