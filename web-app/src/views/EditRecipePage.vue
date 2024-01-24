<template>
    <div class="container-md mt-3 mb-5">
        <RecipeForm :recipe="recipe" :editMode="true" />
    </div>
</template>

<script>
import RecipeForm from '../components/RecipeForm.vue';
import recipesService from '../recipesService.js';

export default {
    name: "EditRecipePage",
    components: { RecipeForm },
    data() {
        return {
            recipe: null,
        };
    },
    async created() {
        const recipeId = Number(this.$route.params.Id);
        this.recipe = await recipesService.getRecipe(recipeId);
        console.log(this.recipe);
    },
}
</script>