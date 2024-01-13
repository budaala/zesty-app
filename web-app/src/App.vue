<template>
  <div>
    <navbar :swapComponent="swapComponent"></navbar>
    <component :is="currentComponent"></component>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'
import RecipeList from './components/RecipeList.vue'
import LogInPage from './components/LogInPage.vue';
import AddRecipe from './components/AddRecipe.vue';

export default {
  name: 'App',
  components: {
    'Navbar': Navbar,
    'Recipes': RecipeList,
    'LogInPage': LogInPage,
    'AddRecipe': AddRecipe
  },
  data() {
    return {
      currentComponent: 'Recipes', // Początkowy stan
    };
  },
  methods: {
    swapComponent(component) {
      this.currentComponent = component;
    }
  },
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
  color: #7D8A51 !important;
  background-color: #f8f9fa !important;
  border-color: #7D8A51 !important;
}

.btn-outline-zesty {
  color: #f8f9fa !important;
  background-color: #1A2A15 !important;
  border-color: #7D8A51 !important;
}
</style>
