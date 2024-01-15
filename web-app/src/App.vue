<template>
  <div>
    <navbar></navbar>
    <router-view/>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'
import RecipeList from './components/RecipeList.vue'
import LogInPage from './views/LogInPage.vue';
import AddRecipe from './views/AddRecipePage.vue';

export default {
  name: 'App',
  components: {
    'Navbar': Navbar,
    'Recipes': RecipeList,
    'LogInPage': LogInPage,
    'AddRecipe': AddRecipe
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Source+Sans+Pro:wght@300;400;600;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Spectral:wght@300;400;600;700&display=swap');

#app {
  font-family: "Source Sans Pro", sans-serif !important;
  font-size: medium !important;
}

body {
  position: relative;
  background-color: #f8f9fa !important;
}

h1 {
  font-family: "Spectral", serif !important;
  color: #1A2A15;
  font-weight: 600 !important;
}

h2 {
  font-family: "Spectral", serif !important;
  color: #7D8A51 !important;
}

.btn-outline-zesty:hover {
  color: #f8f9fa !important;
  background-color: #7D8A51 !important;
}

.btn-outline-zesty {
  color: #1A2A15 !important;
  background-color: #f8f9fa !important;
  border-color: #7D8A51 !important;
  padding: 10px 20px !important;
  text-align: center !important;
  border-radius: 12px !important;
  font-weight: 500 !important;
}

.form-control:focus {
  border-color: #7D8A51 !important;
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgb(125, 138, 81) !important;
}

</style>
