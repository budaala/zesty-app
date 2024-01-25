<template>
    <div class="card">
        <div class="card-body">
            <br>
            <div class="container text-center">
                <h2 class="card-title">Utwórz konto</h2>
                <p class="card-text">Dołącz do społeczności Zesty</p>
                <br>
            </div>
            <form @submit.prevent="register">
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="text" class="form-control" v-model="form.username" @blur="setTouched('username')"
                                :class="{ 'is-valid': isValid('username'), 'is-invalid': !isValid('username') && touched.username }"
                                id="registerUsername" placeholder="Username">
                            <label class="text-truncate" for="registerUsername">Nazwa użytkownika</label>
                        </div>
                        <div v-if="!isValid('username') && touched.username">
                            <small class="text-danger">{{ message.username }}</small>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="email" class="form-control" v-model="form.email" @blur="setTouched('email')"
                                :class="{ 'is-valid': isValid('email'), 'is-invalid': !isValid('email') && touched.email }"
                                id="registerEmail" placeholder="example@email.com">
                            <label for="registerEmail">Adres email</label>
                        </div>
                        <div v-if="!isValid('email') && touched.email">
                            <small class="text-danger">{{ message.email }}</small>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="password" class="form-control" v-model="form.password"
                                @blur="setTouched('password')"
                                :class="{ 'is-valid': isValid('password'), 'is-invalid': !isValid('password') && touched.password }"
                                id="registerPassword" placeholder="Hasło">
                            <label for="registerPassword">Hasło</label>
                            <div v-if="!isValid('password') && touched.password">
                                <small class="text-danger">{{ message.password }}</small>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center">
                    <div class="col-lg-6 col-md-8 mb-3">
                        <div class="form-floating">
                            <input type="password" class="form-control" v-model="form.repeatPassword"
                                @blur="setTouched('repeatPassword')"
                                :class="{ 'is-valid': isValid('repeatPassword'), 'is-invalid': !isValid('repeatPassword') && touched.repeatPassword }"
                                id="registerRepeatPassword" placeholder="Powtórz hasło">
                            <label for="registerRepeatPassword">Powtórz hasło</label>
                            <div v-if="!isValid('repeatPassword') && touched.repeatPassword">
                                <small class="text-danger">{{ message.repeatPassword }}</small>
                            </div>
                        </div>
                    </div>
                </div>
                <br>
                <div v-if="formSubmitted" class="d-flex justify-content-center">
                    <p :class="{ 'text-danger': registered === false, 'text-success': registered === true }">{{ message.all
                    }}</p>
                </div>
                <div class="d-flex justify-content-center mb-4">
                    <div class="col col-lg-6 col-md-8">
                        <button type="submit" class="btn btn-outline-zesty" @click.prevent="validateInput()">Zarejestruj
                            się</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import userService from '@/userService';
export default {
    name: 'Register',
    data() {
        return {
            form: {
                username: '',
                email: '',
                password: '',
                repeatPassword: ''
            },
            touched: {
                username: false,
                email: false,
                password: false,
                repeatPassword: false
            },
            message: {
                username: '',
                email: '',
                password: '',
                repeatPassword: '',
                all: ''
            },
            formSubmitted: false,
            registered: false
        }
    },
    methods: {
        async validateInput() {
            this.formSubmitted = true;

            if (this.isValid('username') && this.isValid('email') && this.isValid('password') && this.isValid('repeatPassword')) {
                // rejestracja
                var response = await this.register();
                if(response === true)
                {
                    // this.form = {
                    //     username: '',
                    //     email: '',
                    //     password: '',
                    //     repeatPassword: ''
                    // };
                    this.registered = true;
                    this.$router.go();
                }
                else
                {
                    this.message.all = 'Wystąpił błąd podczas rejestracji';
                    // this.form = {
                    //     username: '',
                    //     email: '',
                    //     password: '',
                    //     repeatPassword: ''
                    // };
                    this.registered = false;
                }
            }
            else {
                for (let field in this.touched) {
                    this.setTouched(field);
                    this.isValid(field);
                }
                this.message.all = 'Wypełnij wszystkie pola poprawnie';
            }

        },
        setTouched(field) {
            this.touched[field] = true;
        },
        isValid(field) {
            const { username, email, password, repeatPassword } = this.form;
            switch (field) {
                case 'username':
                    return this.validateUsername(username);
                case 'email':
                    return this.validateEmail(email);
                case 'password':
                    return this.validatePassword(password);
                case 'repeatPassword':
                    return this.validateRepeatPassword(repeatPassword);
                default:
                    return true;
            }

        },
        validateUsername(username) {
            if (username.trim() === '' || username.length < 3) {
                this.message.username = 'Nazwa użytkownika musi mieć co najmniej 3 znaki';
                return false;
            }
            else if (username.length > 20) {
                this.message.username = 'Nazwa użytkownika może mieć maksymalnie 20 znaków';
                return false;
            }
            else if (username === 'username') {
                // sprawdzenie z bazą danych
                this.message.username = 'Nazwa użytkownika jest już zajęta';
                return false;
            }
            return true;
        },
        validateEmail(email) {
            if (email.trim() === '') {
                this.message.email = 'Wypełnij to pole';
                return false;
            }
            else if (email === 'email') {
                // sprawdzenie z bazą danych
                this.message.email = 'Konto z podanym adresem email już istnieje';
                return false;
            }
            else if (!(email.match(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/) !== null)) {
                this.message.email = 'Niepoprawny adres email';
                return false;
            }
            return true;
        },
        validatePassword(password) {
            if (password.trim() === '' || password.length < 8) {
                this.message.password = 'Hasło musi mieć co najmniej 8 znaków';
                return false;
            }
            else if (password.length > 20) {
                this.message.password = 'Hasło może mieć maksymalnie 20 znaków';
                return false;
            }
            return true;
        },
        validateRepeatPassword(repeatPassword) {
            if (repeatPassword !== this.form.password) {
                this.message.repeatPassword = 'Hasła nie są takie same';
                return false;
            }
            else if (repeatPassword.trim() === '') {
                this.message.repeatPassword = 'Wypełnij to pole';
                return false;
            }
            return true;
        },
        async register() {
            var response = await userService.register(this.form.username, this.form.password, this.form.email);
            return response;
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

