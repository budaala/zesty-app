<template>
    <div class="card">
        <div class="card-body">
            <br>
            <div class="container text-center">
                <h2 class="card-title">Zaloguj się</h2>
                <p class="card-text"> Zaloguj się, by móc dodawać przepisy</p>
                <br>
            </div>
            <form @submit.prevent="register">
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="email" class="form-control" v-model="form.email" @blur="setTouched('email')"
                                :class="{ 'is-invalid': !isNotEmpty('email') && touched.email }" id="logInEmail"
                                placeholder="Adres email" required>
                            <label for="logInEmail">Adres email</label>
                            <div v-if="!isNotEmpty('email') && touched.email">
                                <small class="text-danger">{{ message.email }}</small>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="password" class="form-control" v-model="form.password"
                                @blur="setTouched('password')"
                                :class="{'is-invalid': !isNotEmpty('password') && touched.password }"
                                id="logInPassword" placeholder="Hasło" required>
                            <label for="logInPassword">Hasło</label>
                        </div>
                        <div v-if="!isNotEmpty('password') && touched.password">
                                <small class="text-danger">{{ message.password }}</small>
                            </div>
                    </div>
                </div>
                <br>
                <div v-if="validInput === false" class="d-flex justify-content-center">
                    <p class="text-danger">{{ message.all }}</p>
                </div>
                <div class="d-flex justify-content-center mb-4">
                    <div class="col col-lg-6 col-md-8">
                        <button type="submit" class="btn btn-outline-zesty" @click.prevent="validateInput()">Zaloguj
                            się</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import userService from "../userService.js";

export default {
    name: 'LogInPage',
    data() {
        return {
            validInput: {
                type: Boolean
            },
            loggedIn: false,
            message: {
                email: '',
                password: '',
                all: ''
            },
            form: {
                email: '',
                password: ''
            },
            touched: {
                email: false,
                password: false
            },
        }
    },
    methods: {
        setTouched(field) {
            this.touched[field] = true;
        },
        isNotEmpty(field) {
            if (field === 'email') {
                if (this.form.email.trim() === '') {
                    this.message.email = 'Wypełnij to pole!';
                    return false;
                }
                return true;
            }
            else if (field === 'password') {
                if (this.form.password.trim() === '') {
                    this.message.password = 'Wypełnij to pole!';
                    return false;
                }
                return true;
            }

        },
        async validateInput() {
            if (this.isNotEmpty('email') && this.isNotEmpty('password')) {
                // walidacja z bazą danych
                this.loggedIn = true;
                this.validInput = false;
                this.message.all = 'Pomyślnie zalogowano.';
                await this.logIn();
            }
            else {
                for (let field in this.touched) {
                    this.setTouched(field);
                    this.isNotEmpty(field);
                }
                this.validInput = false;
                this.message.all = 'Wypełnij wszystkie pola aby się zalogować.';
            }
        },
        async logIn() {
            try {
                // console.log('Próba logowania...'+ this.form.email + ' ' + this.form.password);
                var token = await userService.login(this.form.email, this.form.password);
                localStorage.setItem('token', token);
                console.log('Zalogowano ' + token);
                this.$router.push({ name: 'RecipeListPage' });
            } catch (error) {
                console.log(error);
            }
        },
        logOut() {
            localStorage.removeItem('token');
            this.$router.push({ name: 'RecipeListPage' });
        }
    }
}
</script>

<style scoped>
.btn-outline-zesty {
    display: block;
    width: 100%;
}

</style>



<!-- import axios from 'axios';

const apiClient = axios.create();

apiClient.interceptors.request.use((config) => {
    const token = localStorage.getItem('token'); // Or get the token from Vuex
    if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
}, (error) => {
    return Promise.reject(error);
}); -->