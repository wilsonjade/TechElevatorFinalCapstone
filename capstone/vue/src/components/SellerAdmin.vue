<template>
  <section class="card" >
    <form v-on:submit.prevent="submitForm()">
      <div>
      <label for="name">Name:</label>
      <input v-model="formData.sellerName" type="text" id="name"  required />
    </div>
    <div>
      <label for="type">Type:</label>
      <input v-model="formData.sellerType" type="text" id="type"  required />
    </div>
<div>
      <label for="address1">Address:</label>
      <input v-model="formData.address1" type="text" id="address1"  />
    </div>
    <div>
      <label for="address2">Address Line 2:</label>
      <input v-model="formData.address2" type="text" id="address2"  />
    </div>
    <div>
      <label for="city">City:</label>
      <input v-model="formData.city" type="text" id="city"  />
    </div>
    <div>
      <label for="state">State:</label>
      <input v-model="formData.state" maxlength="2" type="text" id="state"  />
    </div>
    <div>
      <label for="zip">Zip:</label>
      <input v-model="formData.zip" type="text" id="zip"  />
    </div>
    <div>
      <label for="website">Website:</label>
      <input v-model="formData.website" type="text" id="website" />
    </div>
    <button type="submit">Submit</button>
    </form>
    
  </section>
</template>

<script>
import SellerService from '../services/SellerService';

export default {
  computed: {
    },
  data(){
    return{
      formData: {
        sellerId: 0,
        sellerName: "",
        sellerType: "",
        address1: "",
        address2: "",
        city: "",
        state: "",
        zip: "",
        website: "",
      },

    }
  },
  methods: {
    submitForm() {
      // Handle form submission here

      //if id = 0 , call POST
      if (this.formData.sellerId === 0 || this.formData.sellerId == null) {
       
        SellerService.createSeller(this.formData)
          .then((response) =>{
            alert(
              response.status == 201
                ? "Seller created successfully"
                : response.status
            );
            this.$store.commit('LOAD_SELLERS');
      this.$router.push({ name: "sellersView" });}
          )
          .catch((error) => {
            alert(error.message);
            alert(error.statusText);
          });
      } else {
        //if id != 0 , call PUT
        //maybe need this later
        // SellerService.updateSeller(this.formData.sellerId, this.formData)
        //   .then((response) => {
        //     if (response.status == 200) {
        //       alert("Update successful");
        //     }
        //   })
        //   .catch((error) => alert(error.message));
      }
      
    },
  },
};
</script>

<style>
</style>