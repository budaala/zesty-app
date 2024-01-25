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

const getRecipe = async (recipeId) => {
    try {
        const response = await $http.get(`/recipes/${recipeId}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}


const DeleteRecipe = async (recipeId) => {
    try {
        const response = await $http.delete(`/recipes/${recipeId}`);
        if(response.status === 200) {
            alert('Pomyślnie usunięto przepis!');
            return true;
        }
        else
            return false;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const EditRecipe = async (recipeId, recipeJson, image) => {
    try {
        console.log(recipeJson);
        const formData = new FormData();
        formData.append('recipeJson', JSON.stringify(recipeJson));
        if(image)
            formData.append('image', image);
        const response = await $http.put(`/recipes/${recipeId}`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
        if(response.status === 200) {
            alert('Pomyślnie zedytowano przepis!');
            return true;
        }
        else {
            alert('Nie udało się zedytować przepisu!');
            return false;
        }
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const AddRecipe = async (recipeJson, image) => {
    try {
        recipeJson.userId = 3;
        console.log(recipeJson);
        // recipeJson.mealTypeId = 5;
        const formData = new FormData();
        formData.append('recipeJson', JSON.stringify(recipeJson));
        if(image)
            formData.append('image', image);
        const response = await $http.post('/recipes', formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
        if(response.status === 200) {
            alert('Pomyślnie dodano przepis!');
            return true;
        }
        else
            return false;
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
        if(response.status === 200) {
            alert('Pomyślnie dodano ocenę!');
            return true;
        }
        else
            return false;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const getMealTypes = async () => {
    try {
        const response = await $http.get('/recipes/mealtypes');
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
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const loadComments = async (recipeId) => {
    try {
        const response = await $http.get(`/recipes/${recipeId}/comments`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

const addComment = async (recipeId, comment) => {
    try {
        const commentData = {
            content: comment,
            userId: 3
        };
        console.log(commentData);
        const response = await $http.post(`/recipes/${recipeId}/comments`, commentData);
        if(response.status === 200) {
            alert('Pomyślnie dodano komentarz!');
            return true;
        }
        else
            return false;
    } catch (error) {
        console.error('Error loading data:', error);
        return [];
    }
}

export default {
    loadRecipes,
    LoadAllRecipes,
    LoadAverageRating,
    getRecipe,
    DeleteRecipe,
    EditRecipe,
    AddRecipe,
    addRating,
    getMealTypes,
    checkUserRating,
    loadComments,
    addComment
};