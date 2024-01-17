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
                        <input type="text" class="form-control" id="floatingUsername" placeholder="Username">
                        <label for="floatingUsername">Nazwa użytkownika</label> 
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating mb-3">
                        <input type="email" class="form-control" id="floatingInput" placeholder="example@email.com">
                        <label for="floatingInput">Adres email</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center mb-3">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingPassword" placeholder="Hasło">
                        <label for="floatingPassword">Hasło</label>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center">
                <div class="col-lg-6 col-md-6">
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingRepeatPassword" placeholder="Powtórz hasło">
                        <label for="floatingRepeatPassword">Powtórz hasło</label>
                    </div>
                </div>
                <!-- <form class="row g-3">
                    <div class="col-md-4">
                        <label for="validationServer01" class="form-label">First name</label>
                        <input type="text" class="form-control is-valid" id="validationServer01" value="Mark" required>
                        <div class="valid-feedback">
                            Looks good!
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label for="validationServer02" class="form-label">Last name</label>
                        <input type="text" class="form-control is-valid" id="validationServer02" value="Otto" required>
                        <div class="valid-feedback">
                            Looks good!
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label for="validationServerUsername" class="form-label">Username</label>
                        <div class="input-group has-validation">
                            <span class="input-group-text" id="inputGroupPrepend3">@</span>
                            <input type="text" class="form-control is-invalid" id="validationServerUsername"
                                aria-describedby="inputGroupPrepend3 validationServerUsernameFeedback" required>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Please choose a username.
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label for="validationServer03" class="form-label">City</label>
                        <input type="text" class="form-control is-invalid" id="validationServer03"
                            aria-describedby="validationServer03Feedback" required>
                        <div id="validationServer03Feedback" class="invalid-feedback">
                            Please provide a valid city.
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label for="validationServer04" class="form-label">State</label>
                        <select class="form-select is-invalid" id="validationServer04"
                            aria-describedby="validationServer04Feedback" required>
                            <option selected disabled value="">Choose...</option>
                            <option>...</option>
                        </select>
                        <div id="validationServer04Feedback" class="invalid-feedback">
                            Please select a valid state.
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label for="validationServer05" class="form-label">Zip</label>
                        <input type="text" class="form-control is-invalid" id="validationServer05"
                            aria-describedby="validationServer05Feedback" required>
                        <div id="validationServer05Feedback" class="invalid-feedback">
                            Please provide a valid zip.
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="form-check">
                            <input class="form-check-input is-invalid" type="checkbox" value="" id="invalidCheck3"
                                aria-describedby="invalidCheck3Feedback" required>
                            <label class="form-check-label" for="invalidCheck3">
                                Agree to terms and conditions
                            </label>
                            <div id="invalidCheck3Feedback" class="invalid-feedback">
                                You must agree before submitting.
                            </div>
                        </div>
                    </div>
                    <div class="col-12">
                        <button class="btn btn-primary" type="submit">Submit form</button>
                    </div>
                </form> -->
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