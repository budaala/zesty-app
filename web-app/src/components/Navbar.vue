<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary navbar-dark">
        <div class="container-md">
            <router-link class="navbar-brand" to="/">
                <img src="../assets/logo.png" class="logo">
                Zesty</router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" to="/">Strona
                            główna</router-link>
                    </li>
                    <li class="nav-item"  v-for="mealType in mealTypes" :key="mealType.id">
                        <router-link class="nav-link" active-class="active" aria-current="page"
                            :to="{ name: 'RecipeListPage', params: { RecipeType: mealType.name } }">{{ mealType.name }}</router-link>
                    </li>
                    <div class="vr" style="color:aliceblue"></div>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" to="/myRecipes">Moje
                            przepisy</router-link>
                    </li>
                </ul>
                <div class="d-flex align-items-center">
                    <div class="flex-column me-2">
                        <router-link class="btn btn-outline-zesty me-2" to="/addRecipe">Dodaj przepis</router-link>
                        <router-link class="btn btn-outline-zesty" to="/logIn" v-if="!loggedIn">Zaloguj się</router-link>
                    </div>
                    <div class="flex-column me-2" v-if="loggedIn">
                        <div class="btn-group">
                            <font-awesome-icon icon="user" class="user-icon dropdown-toggle" data-bs-toggle="dropdown"
                                aria-expanded="false" size="lg" />
                            <div class="dropdown-menu">
                                <div class="user-menu">
                                    <div class="user-info">
                                        <div class="user-name">Jan Kowalski</div>
                                    </div>
                                    <hr>
                                    <button class="btn user-menu-btn btn-dismiss">Wyloguj się</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
import recipesService from '../recipesService.js';
export default {
    name: 'Navbar',
    data() {
        return {
            loggedIn: false,
            mealTypes: null,
        }
    },
    async mounted() {
        this.mealTypes = await recipesService.getMealTypes();
    },

}
</script>

<style scoped>
.navbar {
    background-color: #7D8A51 !important;
}

.nav-link.active {
    font-size: large;
    /* text-shadow: 0 0 5px #1A2A15;` */
}

.navbar-brand {
    font-family: "Spectral", serif !important;
    font-weight: 800 !important;
    font-size: 2rem !important;
}

.btn-outline-zesty {
    background-color: #f8f9fa !important;
    color: #1A2A15 !important;
}

.btn-outline-zesty:hover {
    background-color: #1A2A15 !important;
    color: #f8f9fa !important;
}

.logo {
    width: 40px;
    height: 40px;
}

.user-icon {
    cursor: pointer;
    color: #f8f9fa !important;
}

.user-icon:hover,
.user-icon:focus,
.user-icon:active {
    color: #1A2A15 !important;
}

.dropdown-menu {
    position: absolute;
    top: 130% !important;
    right: 10% !important;
    width: 250px;
    overflow: hidden;
    background-color: white;
    border: 1px solid #7D8A51 !important;
}

.user-menu {
    padding: 10px;
    margin: 5px;
    border-radius: 5px;
}

.user-info {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.user-name {
    font-size: 1.5rem;
    font-weight: 600;
}

.user-menu hr {
    border: 0;
    height: 1px;
    width: 100%;
    background-color: #1A2A15;
    margin: 15px 0 10px;
}

.user-menu-btn {
    display: block;
    width: 100%;
    text-align: center;
    padding: 5px 0;
    font-size: 1.2rem;
    font-weight: 600;
    text-decoration: none;
}
</style>