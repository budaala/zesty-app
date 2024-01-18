<template>
    <div class="row row-cols-md-3 row-cols-xs-1 mt-2">
        <div class="col" v-for="recipe in recipes" :key="recipe.Id">
            <recipe-card :Title="recipe.Title" :Description="recipe.Description" :Image="recipe.Image">
            </recipe-card>
        </div>
    </div>
</template>

<script>
import RecipeCard from './RecipeCard.vue'

export default {
    name: 'RecipeList',
    components: {
        RecipeCard
    },
    props: {
        recipes: Array,
    }
}

</script>

<style scoped></style>