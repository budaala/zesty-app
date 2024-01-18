<template>
    <div class="container-md mt-3 mb-5">
        <h1>Gotuj z Zesty!</h1>
        <p>Przepisy z kategorii: {{ RecipeType }}</p>
        <RecipeList :recipes="pagedItems"></RecipeList>
        <nav v-show="totalPages > 1">
            <ul class="pagination justify-content-center">
                <li class="page-item" :class="{ disabled: currentPage === 1 }">
                    <a class="page-link" @click="goToPage(currentPage - 1)">&laquo;</a>
                </li>

                <li class="page-item" v-for="page in totalPages" :key="page" :class="{ active: page === currentPage }">
                    <a class="page-link" @click="goToPage(page)">{{ page }}</a>
                </li>

                <li class="page-item" :class="{ disabled: currentPage === totalPages }">
                    <a class="page-link" @click="goToPage(currentPage + 1)">&raquo;</a>
                </li>
            </ul>
        </nav>
    </div>
</template>

<script>
import RecipeList from '../components/RecipeList.vue'
import recipesService from '../recipesService.js';
import paginationMixin from '../paginationMixin.js';

export default {
    name: 'HomePage',
    mixins: [paginationMixin],
    components: {
        RecipeList
    },
    props: ['RecipeType'],
    data() {
        return {
            recipes: [],
            items: [],
        }
    },
    mounted() {
        this.loadRecipes();
    },
    watch: {
        $route() {
            this.loadRecipes();
        },
    },
    methods: {
        async loadRecipes() {
            try {
                this.recipes = await recipesService.loadRecipes();
                if (this.RecipeType) {
                    this.items = this.recipes.filter((recipe) => recipe.RecipeType === this.RecipeType);
                } else {
                    this.items = this.recipes;
                }
            } catch (error) {
                // Obsługa błędu
            }
        },
    }
}
</script>