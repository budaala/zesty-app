<template>
    <div class="container-md mt-3">
        <h1>Gotuj z Zesty!</h1>
        <RecipeList :recipes="recipes"></RecipeList>
    </div>
</template>

<script>
import RecipeList from '../components/RecipeList.vue'
import recipesService from '../recipesService.js';

export default {
    name: 'HomePage',
    components: {
        RecipeList
    },
    data() {
        return {
            recipes: [

            ]
        }
    },
    mounted() {
        this.loadRecipes();
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