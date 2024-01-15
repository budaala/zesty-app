import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';
import App from './App.vue';
import 'bootstrap/dist/css/bootstrap.css';

import HomePage from '../src/views/HomePage.vue';
import RecipeList from '../src/components/RecipeList.vue';
import LogInPage from '../src/views/LogInPage.vue';
import AddRecipe from '../src/views/AddRecipePage.vue';
import MyRecipes from '../src/views/MyRecipesPage.vue';

const routes = [
    { path: '/', component: HomePage },
    { path: '/logIn', component: LogInPage },
    { path: '/addRecipe', component: AddRecipe },
    { path: '/myRecipes', component: MyRecipes },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

const app = createApp(App);
app.use(router);
app.mount('#app');