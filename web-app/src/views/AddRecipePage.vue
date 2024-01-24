<template>
    <div class="container-md mt-3 mb-5">
        <RecipeForm :edit-mode="false"/>
    </div>
</template>

<script>
import RecipeForm from '../components/RecipeForm.vue';
export default {
    name: 'AddRecipe',
    components: { RecipeForm },
};
</script>
