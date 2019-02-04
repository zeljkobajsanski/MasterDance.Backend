<template>
    <div class="single-widget-container">
        <section class="widget login-widget">
            <header class="text-align-center">
                <h4>Molim prijavite se na sistem</h4>
            </header>
            <p class="text-danger text-center" v-if="errorMessageVisible">Neuspela prijava</p>
            <div class="body">
                <form class="no-margin" @submit.prevent="login">
                    <fieldset>
                        <div class="form-group" :class="{'has-error': errors.has('email')}">
                            <label for="email" >Email</label>
                            <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-user"></i>
                                    </span>
                                <input id="email" type="email" class="form-control input-lg input-transparent" v-model="username"
                                       placeholder="Email" name="email" v-validate="'required|email'" autocomplete="on">
                            </div>
                        </div>
                        <div class="form-group" :class="{'has-error': errors.has('password')}">
                            <label for="password" >Lozinka</label>

                            <div class="input-group input-group-lg">
                                    <span class="input-group-addon">
                                        <i class="fa fa-lock"></i>
                                    </span>
                                <input id="password" type="password" class="form-control input-lg input-transparent"
                                       v-model="password" name="password" v-validate="'required'"
                                       placeholder="Lozinka">
                            </div>
                        </div>
                    </fieldset>
                    <div class="form-actions">
                        <button type="submit" class="btn btn-block btn-lg btn-danger" :disabled="errors.any()">
                            <span class="small-circle"><i class="fa fa-caret-right"></i></span>
                            <small>Prijavi me</small>
                        </button>
                        <!--<a class="forgot" href="#">Forgot Username or Password?</a>-->
                    </div>
                </form>
            </div>
           <!-- <footer>
                &lt;!&ndash;<div class="facebook-login">&ndash;&gt;
                    &lt;!&ndash;<a href="index.html"><span><i class="fa fa-facebook-square fa-lg"></i> LogIn with Facebook</span></a>&ndash;&gt;
                &lt;!&ndash;</div>&ndash;&gt;
            </footer>-->
        </section>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import {Prop, Component, Watch} from 'vue-property-decorator';
    import authenticationProxy from '../services/AuthenticationProxy'

    @Component({})
    export default class Login extends Vue {
        username = '';
        password = '';
        errorMessageVisible = false;

        login() {
            this.errorMessageVisible = false;
            authenticationProxy.login(this.username, this.password).then(() => {
               this.$router.push('/');
            }).catch((err) => {
                this.errorMessageVisible = true;
            });
        }
    }
</script>

<style scoped>
    .login-widget .form-actions {
        height: 75px;
    }

    .has-error .input-group-addon {
        background-color: red;
    }

</style>