<template>
    <form v-on:submit.prevent="submitPollResponse()" class="communication-detail card poll">
      <h3>{{ item.title }}</h3>
      <div>
        <input type="radio" name="poll-item" id="poll-option1" />
        <label for="poll-option1">{{ item.pollOption1 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option2" />
        <label for="poll-option2">{{ item.pollOption2 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option3" />
        <label for="poll-option3">{{ item.pollOption3 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option4" />
        <label for="poll-option4">{{ item.pollOption4 }}</label>
      </div>

      <button>Submit your answer!</button>
    </form>
</template>

<script>
export default {
  name: "communicationsDetail",
  props: ["item"],
  methods: {
    submitPollResponse() {
      
    }
  }
};
</script>

<style scoped>
h1 {
  text-align: center;
}

.poll {
  display: flex;
  flex-direction: column;
}

div {
  padding: 4px;
}
</style>