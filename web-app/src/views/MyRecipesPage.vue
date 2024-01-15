<template>
    <div class="container-md mt-3">
        <h1>Twoje przepisy</h1>
        <RecipeList :recipes="selectedRecipes"></RecipeList>
    </div>
</template>

<script>
import RecipeList from '../components/RecipeList.vue'
import recipesService from '../recipesService.js';

export default {
    name: 'MyRecipes',
    components: {
        RecipeList
    },
    data() {
        return {
            recipes: [

            ],
            selectedRecipeIds: [1, 3], // Indeksy przepisów, które chcesz wyświetlić
        };
    }, mounted() {
        this.loadRecipes();
    },
    computed: {
        selectedRecipes() {
            // Filtruj przepisy na podstawie wybranych identyfikatorów
            return this.recipes.filter((recipe) => this.selectedRecipeIds.includes(recipe.id));
        },
    },
    methods: {
        async loadRecipes() {
            try {
                this.recipes = await recipesService.loadRecipes();
            } catch (error) {
                // Obsługa błędu
            }
        },
    }
}
</script>