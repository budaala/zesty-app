// recipesService.js

export default {
    async loadRecipes() {
        try {
            const response = await fetch('recipes.json');
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Błąd ładowania danych:', error);
            throw error;
        }
    },
};
