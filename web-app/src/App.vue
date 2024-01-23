<template>
  <div>
    <navbar></navbar>
    <router-view />
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'
import RecipeListPage from './views/RecipeListPage.vue'
import LogInPage from './views/LogInPage.vue';
import AddRecipePage from './views/AddRecipePage.vue';

export default {
  name: 'App',
  components: {
    'Navbar': Navbar,
    'RecipeListPage': RecipeListPage,
    'LogInPage': LogInPage,
    'AddRecipePage': AddRecipePage
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Source+Sans+Pro:wght@300;400;600;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Spectral:wght@300;400;600;700&display=swap');

#app {
  font-family: "Source Sans Pro", sans-serif !important;
  font-size: medium !important;
  /* delete */
  /* color : #f8f9fa !important;  */
}

body {
  position: relative;
  /* change */
  background-color: #f8f9fa !important;
  /* background-color: #343434 !important; */
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

h3 {
  font-family: "Spectral", serif !important;
  color: #1A2A15 !important;
}

.btn-outline-zesty:hover {
  color: #f8f9fa !important;
  background-color: #7D8A51 !important;
}

.btn-outline-zesty {
  color: #f8f9fa !important;
  background-color: #1A2A15 !important;
  padding: 10px 20px !important;
  text-align: center !important;
  border-radius: 12px !important;
  font-weight: 500 !important;
}

.form-control:focus,
.form-select:focus {
  border-color: #7D8A51 !important;
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 8px rgb(125, 138, 81) !important;
}

.pagination>li>a {
  background-color: white;
  color: #1A2A15;
  cursor: pointer;
}

.pagination>li>a:focus,
.pagination>li>a:hover,
.pagination>li>span:focus,
.pagination>li>span:hover {
  color: #5a5a5a;
  background-color: #eee;
  border-color: #ddd;
}

.pagination>.active>a {
  color: white;
  background-color: #7D8A51 !Important;
  border: solid 1px #7D8A51 !Important;
}

.pagination>.active>a:hover {
  background-color: #7D8A51 !Important;
  border: solid 1px #7D8A51;
}

.alert-zesty {
  color: #7D8A51 !important;
  background-color: #7d8a513e !important;
  border-color: #7D8A51 !important;
  font-size: large;
}

.r-link {
  color: #1A2A15 !important;
}

.btn-dismiss {
  background-color: #9d0616 !important;
  border-color: #64030d !important;
  color: #f8f9fa !important;
  padding: 10px 20px !important;
  text-align: center !important;
  border-radius: 12px !important;
  font-weight: 500 !important;
}

.btn-dismiss:hover {
  background-color: #64030d !important;
}
</style>
