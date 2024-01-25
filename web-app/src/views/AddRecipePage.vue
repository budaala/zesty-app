<template>
    <div class="container-md mt-3 mb-5" v-if="isLoggedIn()">
        <RecipeForm :edit-mode="false"/>
    </div>
    <div class="container-md mt-3 mb-5" v-else>
        <h2>Zaloguj się, aby dodać przepis</h2>
    </div>
</template>

<script>
import RecipeForm from '../components/RecipeForm.vue';

export default {
    name: 'AddRecipe',
    components: {RecipeForm},
    methods:{
        isLoggedIn(){
            return localStorage.getItem('user') !== null && localStorage.getItem('user') !== undefined;
        }
    }
};
</script>
