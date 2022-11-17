import React, { useState } from 'react';
import axios from 'axios';
import User from './User';

export default function LoginForm(props) {

    //properties passed from parent component
    const handleLoginSubmit = props.handleLoginSubmit;
    const url = props.url + '/api/account/authenticate';

    //state
    const [username, setUsername] = useState('acc1');
    const [password, setPassword] = useState('test');

    async function authenticate(event) {
        event.preventDefault();
        const json = { username: username, password: password };
        try {
            const response = await axios.post(url, json);
            const user = new User(username,
                response.data.name, response.data.token);
            console.log(user.token);
            handleLoginSubmit(user);
        } catch (error) {
            console.error(error.response.status)
        }
    }   

    return <form>
        <h5>Login Form</h5>
        <div className="form-group">
            <label>Username</label>
            <input className="form-control" value={username} onChange={(e) => setUsername(e.target.value)} />
        </div>
        <div className="form-group">
            <label>Password</label>
            <input className="form-control" value={password} onChange={(e) => setPassword(e.target.value)} />
        </div>
        <button onClick={authenticate} type="submit" className="btn btn-primary">Submit</button>
        <hr />
    </form>
}