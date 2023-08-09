<template>
  <section>
    <h1>SellerAdmin.vue</h1>

    
  </section>
</template>

<script>
import SellerService from '../services/SellerService';

export default {
  computed: {
    userid() {
      return this.$store.state.user.userId;
    },
  },
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
  methods: {
    submitForm() {
      // Handle form submission here

      //if id = 0 , call POST
      if (this.formData.sellerId === 0 || this.formData.sellerId == null) {
        this.formData.userid = this.userid; //set userId

        const sendObj = this.formData;
        delete sendObj.sellerId;
        SellerService.createSeller(sendObj)
          .then((response) =>
            alert(
              response.status == 201
                ? "Seller created successfully"
                : response.status
            )
          )
          .catch((error) => {
            alert(error.message);
            alert(error.statusText);
          });
      } else {
        //if id != 0 , call PUT
        SellerService.updateSeller(this.formData.sellerId, this.formData)
          .then((response) => {
            if (response.status == 200) {
              alert("Update successful");
            }
          })
          .catch((error) => alert(error.message));
      }
      this.$router.push({ name: "sellersView" });
    },
  },
};
</script>

<style>
</style>