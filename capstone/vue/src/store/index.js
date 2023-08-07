import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

import plantService from "../services/PlantService.js";

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},

    plants: [],
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },

    LOAD_PLANTS(state) {
      plantService.listPlants()
      .then( (response) => {
        state.plants = response.data;
      } )
      .catch((error) => {
        if (error.response) { 
          // error.response exists
          // Request was made, but response has error status (4xx or 5xx)
          console.log("Error loading plants: ", error.response.status)
        
        } else if (error.request) { 
          // There is no error.response, but error.request exists
          // Request was made, but no response was received
          console.log("Error loading plants: unable to communicate to server")
      
        } else { 
          // Neither error.response and error.request exist
          // Request was *not* made
          console.log("Error loading plants: make request")
        }
      });
    }
  }
})
