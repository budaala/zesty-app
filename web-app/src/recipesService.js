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
    baseURL: "https://localhost:7200/api",
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
        console.log(response.data);
        return response.data;
        } catch (error) {
        console.error('Error loading data:', error);
        return [];
        }
}


export default {
    loadRecipes,
    LoadAllRecipes
};