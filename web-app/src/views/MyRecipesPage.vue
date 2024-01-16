<template>
    <div class="container-md mt-3 mb-5">
        <h1>Twoje przepisy</h1>
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
    name: 'MyRecipes',
    mixins: [paginationMixin],
    components: {
        RecipeList
    },
    data() {
        return {
            recipes: [],
            selectedRecipeIds: [1, 3, 4, 5], // Indeksy przepisów, które chcesz wyświetlić
            items: []
        };
    }, mounted() {
        this.loadRecipes();
    },
    methods: {
        async loadRecipes() {
            try {
                this.recipes = await recipesService.loadRecipes();
                this.items = this.recipes.filter((recipe) => this.selectedRecipeIds.includes(recipe.id));
            } catch (error) {
                // Obsługa błędu
            }
        },
    }
}
</script>