<template>
    <div class="container-md mt-3 mb-5" v-if="isLoggedIn()">
        <RecipeForm :edit-mode="false"/>
    </div>
    <div class="container-md mt-3 mb-5" v-else>
        <Alert :message="'Aby móc dodawać przepisy, należy być zalogowanym.'" :type="'danger'"/>
    </div>
</template>

<script>
import RecipeForm from '../components/RecipeForm.vue';
import Alert from '../components/Alert.vue';

export default {
    name: 'AddRecipe',
    components: {RecipeForm, Alert},
    methods:{
        isLoggedIn(){
            return localStorage.getItem('user') !== null && localStorage.getItem('user') !== undefined;
        }
    }
};
</script>