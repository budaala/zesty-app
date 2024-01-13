<template>
    <div class="container-md">
        <h1>Gotuj z Zesty!</h1>
        <!-- <h2>How you doin'?</h2>
        <p>tu się pojawi main content</p> -->
        <div class="row row-cols-3">
            <div class="col" v-for="(recipe) in recipes">
                <recipe-card
                    :name="recipe.name"
                    :description="recipe.description"
                    :image="recipe.image">
                </recipe-card>
            </div>
        </div>
    </div>
</template>

<script>
import RecipeCard from './RecipeCard.vue'

export default {
    name: 'RecipeList',
    props: ['swapComponent'],
    components: {
        RecipeCard
    },
    data() {
        return {
            recipes: []
        };
    },
    mounted() {
        this.loadRecipes();
    },
    methods: {
        loadRecipes() {
            fetch('recipes.json')
                .then(response => response.json())
                .then(data => {
                    this.recipes = data;
                })
                .catch(error => {
                    console.error('Błąd ładowania danych:', error);
                });
        }
    }
}

</script>

<style scoped></style>