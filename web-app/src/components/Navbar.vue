<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary navbar-dark">
        <div class="container-md">
            <a class="navbar-brand" href="#" @click="changeToMainPage">
                <img src="../assets/logo.png" class="logo">
                Zesty</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="#" @click="changeToMainPage">Strona główna</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="#" @click="changeToMainPage">Moje przepisy</a>
                    </li>
                </ul>
                <div class="d-flex">
                    <button class="btn btn-outline-zesty me-2" @click="changeToAddRecipePage">Dodaj przepis</button>
                    <!-- Jeśli zalogowany - ikonka konta, jeśli nie - przycisk zaloguj się / zarejestruj -->
                    <button class="btn btn-outline-zesty" @click="changeToLogInPage">Zaloguj</button>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
export default {
    name: 'Navbar',
    props: {
        swapComponent: {
            type: Function
        }
    },
    methods: {
        changeToLogInPage() {
            this.swapComponent('LogInPage');
        },
        changeToMainPage() {
            this.swapComponent('Recipes');
        },
        changeToAddRecipePage() {
            this.swapComponent('AddRecipe');
        }
    }
}
</script>

<style scoped>
.navbar {
    background-color: #7d8a51d9 !important;
}

.navbar-brand {
    font-family: "Spectral", serif !important;
    font-weight: 800 !important;
    font-size: 2rem !important;
}

.btn-outline-zesty:hover {
    color: #FFFFFF !important;
    background-color: #1A2A15;
    border-color: #1A2A15 !important;
}

.btn-outline-zesty {
    color: #1A2A15 !important;
    background-color: #FFFFFF !important;
    border-color: #1A2A15 !important;
}

.logo {
    width: 45px;
    height: 45px;
}
</style>