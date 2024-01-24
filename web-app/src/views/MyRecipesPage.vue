<template>
    <div class="container-md mt-3 mb-5">
        <h1>Twoje przepisy</h1>
        <RecipeList :recipes="items"></RecipeList>
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
            recipes: [],
            items: []
        };
    }, mounted() {
        this.loadRecipes();
    },
    methods: {
        async loadRecipes() {
            try {
                this.recipes = await recipesService.LoadAllRecipes();
                this.items = this.recipes.filter((recipe) => recipe.userId === 3);
                console.log(this.items)
            } catch (error) {
                // Obsługa błędu
            }
        },
    }
}
</script>