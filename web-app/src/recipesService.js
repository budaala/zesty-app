// export default {
//     async loadRecipes() {
//         try {
//             const response = await fetch('recipes.json');
//             const data = await response.json();
//             return data;
//         } catch (error) {
//             console.error('Błąd ładowania danych:', error);
//             throw error;
//         }
//     },
// };

// ala url http://localhost:5033/api

import axios from "axios";
const $http = axios.create({
    baseURL: "http://localhost:5033/api",
    headers: {
        "Content-type": "application/json"
    }
});

const loadRecipes = async () => {
    try {
        const response = await fetch('/recipes.json');
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
};

const LoadAllRecipes = async () => {
    try {
        const response = await $http.get('/recipes');
        console.log(response.data);
        return response.data;
        } catch (error) {
        console.error('Error loading data:', error);
        return [];
        }
}

const LoadAverageRating = async (recipeId) => {
    try {
        const response = await $http.get(`/recipes/${recipeId}/averagerating`);
        return response.data;
        } catch (error) {
        console.error('Error loading data:', error);
        return [];
        }
}

const addRating = async (recipeId, rating, userId) => {
    try {
        const ratingData = {
            value: rating,
            userId: userId
        };
        const response = await $http.post(`/recipes/${recipeId}/rating`, ratingData);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const getMealTypes = async () => {
    try {
        const response = await $http.get('/mealtypes');
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

//check if user already rated recipe
const checkUserRating = async (recipeId, userId) => {
    try {
        const response = await $http.get(`/recipes/${recipeId}/rating/${userId}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}




export default {
    loadRecipes,
    LoadAllRecipes,
    LoadAverageRating,
    addRating,
    getMealTypes,
    checkUserRating
};