import { useState, useEffect } from 'react';

export default function Clock(props){
    const[date, setDate] = useState(new Date());

    //executed after React has updated the DOM.
    //runs after the first render and after every update
    useEffect(()=>{
        console.log("setInterval");
        //
        let timerId = setInterval(()=>setDate(new Date()),1000);
        //optional cleanup function
        return ()=>{
            console.log("cleanup");
            clearInterval(timerId);
        }
    },[]);
    return date.toLocaleTimeString();
}