<template>
    <div class="card">
        <div class="card-body">
            <br>
            <div class="container text-center">
                <h2 class="card-title">Zaloguj się</h2>
                <p class="card-text"> Zaloguj się, by móc dodawać przepisy</p>
                <br>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating mb-3">
                        <input type="email" class="form-control" id="floatingInput">
                        <label for="floatingInput">Adres email</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingPassword">
                        <label for="floatingPassword">Hasło</label>
                    </div>
                </div>
            </div>
            <br>
            <div class="d-flex justify-content-center mb-4">
                <div class="col col-lg-4">
                    <button type="submit" class="btn btn-outline-zesty">Zaloguj się</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'LogInPage'

}
</script>

<style scoped>
.btn-outline-zesty {
    display: block;
    width: 100%;
}
</style>