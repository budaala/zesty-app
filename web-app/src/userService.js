import axios from "axios";
import {jwtDecode} from "jwt-decode";

const $http = axios.create({
    baseURL: "http://localhost:5033/api",
    headers: {
        "Content-type": "application/json"
    }
});

const login = async (username, password) => {
    try {
        const loginData = {
            username: username,
            password: password
        };
        const response = await $http.post('/auth/login', loginData);
        if(response.status === 200)
        {
            localStorage.setItem('token', response.data);
            setUser();
            alert('Zalogowano!');
            return true;
        }
        else
            return false;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
};

const register = async (username, password, email) => {
    try {
        const response = await $http.post('/auth/register', { username, password, email });
        if(response.status === 200){
            return true;
        }
        return false;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const logout = async () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('username');
    alert('Wylogowano!');
}

const setUser = () => {
    var token = localStorage.getItem('token');
    if (token) {
        var decodedToken = jwtDecode(token);
        // console.log(decodedToken);
        var nameidentifier = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        var username = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
        localStorage.setItem('user', nameidentifier);
        localStorage.setItem('username', username);
        // console.log(localStorage.getItem('user') + ' ' + localStorage.getItem('username'));
    }
    else
    console.log('token not found');
}



export default {
    login,
    register,
    logout
};