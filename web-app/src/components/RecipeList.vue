<template>
    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 mt-2">
        <div class="col" v-for="recipe in recipes" :key="recipe.Id">
            <recipe-card :Id="recipe.Id" :Title="recipe.Title" :Description="recipe.Description" :Image="recipe.Image">
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
