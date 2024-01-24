import axios from "axios";

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
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
};

const register = async (username, password, email) => {
    try {
        const response = await $http.post('/auth/register', { username, password, email });
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}










export default {
    login,
    register
};