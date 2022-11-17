
const axios = require('axios'); //https://github.com/axios/axios
const url = 'https://sdineen.uk/api/product';
axios.get(url)
.then(response => console.log(response.data))
.catch(error => console.log(error));

axios.get(url).then(response =>
    response.data.forEach(item => console.log(item.name)));