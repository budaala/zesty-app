<template>
  <navbar>

  </navbar>
  <recipe-list>
    
  </recipe-list>
</template>

<script>
import Navbar from './components/Navbar.vue'
import RecipeList from './components/RecipeList.vue'

export default {
  name: 'App',
  components: {
    Navbar,
    RecipeList
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

.btn-outline-zesty {
  color: #7D8A51 !important;
  border-color: #7D8A51 !important;
}

.btn-outline-zesty:hover {
  color: #f8f9fa !important;
  background-color: #1A2A15 !important;
  border-color: #7D8A51 !important;
}

</style>
