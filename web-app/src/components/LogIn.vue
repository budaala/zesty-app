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
                            <input type="text" class="form-control" v-model="form.username" @blur="setTouched('username')"
                                :class="{ 'is-invalid': !isNotEmpty('username') && touched.username }" id="logInusername"
                                placeholder="Adres username" required>
                            <label for="logInusername">Nazwa użytkownika</label>
                            <div v-if="!isNotEmpty('username') && touched.username">
                                <small class="text-danger">{{ message.username }}</small>
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
                username: '',
                password: '',
                all: ''
            },
            form: {
                username: '',
                password: ''
            },
            touched: {
                username: false,
                password: false
            },
        }
    },
    methods: {
        setTouched(field) {
            this.touched[field] = true;
        },
        isNotEmpty(field) {
            if (field === 'username') {
                if (this.form.username.trim() === '') {
                    this.message.username = 'Wypełnij to pole!';
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
            if (this.isNotEmpty('username') && this.isNotEmpty('password')) {
                // walidacja z bazą danych
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
                this.loggedIn = await userService.login(this.form.username, this.form.password);
                console.log(this.loggedIn);
                this.$router.push({ path: '/'});
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
