<template>
    <div class="card">
        <div class="card-body">
            <br>
            <div class="container text-center">
                <h2 class="card-title">Utwórz konto</h2>
                <p class="card-text">Dołącz do społeczności Zesty</p>
                <br>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating mb-3">
                        <input type="text" class="form-control" id="floatingLogin">
                        <label for="floatingLogin">Login</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating mb-3">
                        <input type="email" class="form-control" id="floatingInput">
                        <label for="floatingInput">Adres email</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center mb-3">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingPassword">
                        <label for="floatingPassword">Hasło</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingRepeatPassword">
                        <label for="floatingRepeatPassword">Powtórz hasło</label>
                    </div>
                </div>
            </div>
            <br>
            <div class="d-flex justify-content-center mb-4">
                <div class="col col-lg-4">
                    <button type="submit" class="btn btn-outline-zesty">Zarejestruj się</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Register'

}
</script>

<style scoped>
.btn-outline-zesty {
    display: block;
    width: 100%;
}
</style>