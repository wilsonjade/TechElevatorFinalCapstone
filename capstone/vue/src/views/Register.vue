<template>
  <div id="register" class="text-center card">
    <form @submit.prevent="register">
      <h1>Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input
          type="password"
          id="confirmPassword"
          v-model="user.confirmPassword"
          required
        />
      </div>

      <div class="form-input-group">
        <label for="expertiseLevel">Level of Expertise</label>
        <select
          name="expertiseLevel"
          input
          type="number"
          id="expertiseLevel"
          v-model.number="user.expertiseLevel"
          required
          autofocus
        >
          <option>1</option>
          <option>2</option>
          <option>3</option>

        </select>
      </div>

      <div class="form-input-group">
        <label for="firstName">First Name</label>
        <input
          type="text"
          id="firstName"
          v-model="user.firstName"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="lastName">Last Name</label>
        <input
          type="text"
          id="lastName"
          v-model="user.lastName"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="email">Email</label>
        <input type="text" id="email" v-model="user.email" required autofocus />
      </div>



      <div class="form-input-group">
        <label for="region">Region</label>
        <select
          name = "region"
          input type="number"
          id="region"
          v-model.number="user.region"
          required
          autofocus
        >

        <option>2</option>
        <option>3</option>
        <option>4</option>
        <option>5</option>
        <option>6</option>
        <option>7</option>
        <option>8</option>
        <option>9</option>
        <option>10</option>

        </select>
      </div>

      <button type="submit">Create Account</button>
      <p>
        <button><router-link :to="{ name: 'login' }"
          >Already have an account? Log in.</router-link
        ></button>
      </p>
    </form>

     <section class="chart-container">
 <img class="chart" src="../assets/plantingzones.jpg" />
    </section>
    
  </div>
  
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
        firstName: "",
        lastName: "",
        expertiseLevel: 0,
        email: "",
        region: 0,
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style scoped>
.form-input-group {
  margin-bottom: 1rem;
  
}
label {
  margin-right: 0.5rem;
}

.chart-container{
  float: right;
  margin-top: 20px;
  align-items: right;
  clear: both;
}
.chart{
  height: 350px;
  width: 400px;
  border-radius: 5%;
} 

</style>
