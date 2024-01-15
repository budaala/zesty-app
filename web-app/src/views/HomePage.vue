<template>
    <div class="container-md mt-3">
        <h1>Gotuj z Zesty!</h1>
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
    data() {
        return {
            recipes: [],
            items: [],
            // currentPage: 1,
            // recipesPerPage: 3
        }
    },
    // computed: {
    //     totalPages() {
    //         return Math.ceil(this.recipes.length / this.recipesPerPage);
    //     },
    //     pagedRecipes() {
    //         const start = (this.currentPage - 1) * this.recipesPerPage;
    //         const end = start + this.recipesPerPage;
    //         return this.recipes.slice(start, end);
    //     }
    // },
    mounted() {
        this.loadRecipes();
    },
    methods: {
        async loadRecipes() {
            try {
                this.recipes = await recipesService.loadRecipes();
                this.items = this.recipes;
            } catch (error) {
                // Obsługa błędu
            }
        },
        // goToPage(page) {
        //     if (page >= 1 && page <= this.totalPages) {
        //         this.currentPage = page;
        //     }
        // }
    }
}
</script>