
const axios = require('axios'); //https://github.com/axios/axios
const url = 'https://sdineen.uk/api';
axios.get(url + '/product/' )
.then(response => console.log(response.data))
.catch(error => console.log(error));

