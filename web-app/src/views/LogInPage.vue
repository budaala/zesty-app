<template>
    <div class="container-md mt-5 mb-5">
        <div class="row row-col-2">
            <div class="col m-2">
                <log-in></log-in>
            </div>
            <div class="col m-2">
                <register></register>
            </div>
        </div>
    </div>
</template>

<script>
import LogIn from '../components/LogIn.vue';
import Register from '../components/Register.vue';

export default {
    name: 'LogInPage',
    components: {
        LogIn,
        Register
    }
}

</script>

<style scoped></style>