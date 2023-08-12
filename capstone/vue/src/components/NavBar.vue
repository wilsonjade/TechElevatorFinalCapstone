<template>
  <nav id="nav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <router-link
          class="nav-link"
          v-bind:to="{ name: 'home' }"
        >
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 576 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4 .1-2.8 .1-4.2 .1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2 .1-2.4 .2-3.6 .2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z"
            />
          </svg>
          <span class="link-text">Home</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link
          class="nav-link"
          v-bind:to="{ name: 'plantDetail', params: { plantId: 1 } }"
        >
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 512 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M512 32c0 113.6-84.6 207.5-194.2 222c-7.1-53.4-30.6-101.6-65.3-139.3C290.8 46.3 364 0 448 0h32c17.7 0 32 14.3 32 32zM0 96C0 78.3 14.3 64 32 64H64c123.7 0 224 100.3 224 224v32V480c0 17.7-14.3 32-32 32s-32-14.3-32-32V320C100.3 320 0 219.7 0 96z"
            />
          </svg>
          <span class="link-text">Plant Detail</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link
          class="nav-link"
          v-bind:to="{ name: 'myStuffView', params: { user: 'id' } }"
        >
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 448 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M224 256A128 128 0 1 0 224 0a128 128 0 1 0 0 256zm-45.7 48C79.8 304 0 383.8 0 482.3C0 498.7 13.3 512 29.7 512H418.3c16.4 0 29.7-13.3 29.7-29.7C448 383.8 368.2 304 269.7 304H178.3z"
            />
          </svg>
          <span class="link-text">My Stuff</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link
          class="nav-link"
          v-bind:to="{ name: 'virtualGardenView', params: { user: 'id' } }"
        >
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 640 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M160 0c-6.3 0-12 3.7-14.6 9.5L120.6 64.9 63.9 43.2c-5.9-2.3-12.6-.8-17 3.6s-5.9 11.1-3.6 17l21.7 56.7L9.5 145.4C3.7 148 0 153.7 0 160s3.7 12 9.5 14.6l55.4 24.8L43.2 256.1c-2.3 5.9-.8 12.6 3.6 17s11.1 5.9 17 3.6l56.7-21.7 24.8 55.4c2.6 5.8 8.3 9.5 14.6 9.5s12-3.7 14.6-9.5l24.8-55.4 56.7 21.7c5.9 2.3 12.6 .8 17-3.6s5.9-11.1 3.6-17l-21.7-56.7 55.4-24.8c5.8-2.6 9.5-8.3 9.5-14.6s-3.7-12-9.5-14.6l-55.4-24.8 21.7-56.7c2.3-5.9 .8-12.6-3.6-17s-11.1-5.9-17-3.6L199.4 64.9 174.6 9.5C172 3.7 166.3 0 160 0zm0 96a64 64 0 1 1 0 128 64 64 0 1 1 0-128zm32 64a32 32 0 1 0 -64 0 32 32 0 1 0 64 0zm312 16c0-17.7 14.3-32 32-32s32 14.3 32 32v53.4c-14.8 7.7-24 23.1-24 44.6c0 16.8 16 44 37.4 67.2c5.8 6.2 15.5 6.2 21.2 0C624 318 640 290.7 640 274c0-21.5-9.2-37-24-44.6V176c0-44.2-35.8-80-80-80s-80 35.8-80 80v22.7c-9.8-4.3-20.6-6.7-32-6.7c-44.2 0-80 35.8-80 80v21.4c-14.8 7.7-24 23.1-24 44.6c0 16.8 16 44 37.4 67.2c5.8 6.2 15.5 6.2 21.2 0C400 382 416 354.7 416 338c0-21.5-9.2-37-24-44.6V272c0-17.7 14.3-32 32-32s32 14.3 32 32v8V448H32c-17.7 0-32 14.3-32 32s14.3 32 32 32H608c17.7 0 32-14.3 32-32s-14.3-32-32-32H504V280v-8V176z"
            />
          </svg>
          <span class="link-text">Virtual Garden</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" v-bind:to="{ name: 'searchView' }">
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 512 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M416 208c0 45.9-14.9 88.3-40 122.7L502.6 457.4c12.5 12.5 12.5 32.8 0 45.3s-32.8 12.5-45.3 0L330.7 376c-34.4 25.2-76.8 40-122.7 40C93.1 416 0 322.9 0 208S93.1 0 208 0S416 93.1 416 208zM208 352a144 144 0 1 0 0-288 144 144 0 1 0 0 288z"
            />
          </svg>
          <span class="link-text">Search</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" v-bind:to="{ name: 'eventsView' }">
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 448 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M128 0c17.7 0 32 14.3 32 32V64H288V32c0-17.7 14.3-32 32-32s32 14.3 32 32V64h48c26.5 0 48 21.5 48 48v48H0V112C0 85.5 21.5 64 48 64H96V32c0-17.7 14.3-32 32-32zM0 192H448V464c0 26.5-21.5 48-48 48H48c-26.5 0-48-21.5-48-48V192zm64 80v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V272c0-8.8-7.2-16-16-16H80c-8.8 0-16 7.2-16 16zm128 0v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V272c0-8.8-7.2-16-16-16H208c-8.8 0-16 7.2-16 16zm144-16c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V272c0-8.8-7.2-16-16-16H336zM64 400v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V400c0-8.8-7.2-16-16-16H80c-8.8 0-16 7.2-16 16zm144-16c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V400c0-8.8-7.2-16-16-16H208zm112 16v32c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16V400c0-8.8-7.2-16-16-16H336c-8.8 0-16 7.2-16 16z"
            />
          </svg>
          <span class="link-text">Events</span>
        </router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" v-bind:to="{ name: 'sellersView' }">
          <svg
            class="nav-icon"
            xmlns="http://www.w3.org/2000/svg"
            height="1em"
            viewBox="0 0 640 512"
          >
            <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
            <path
              d="M36.8 192H603.2c20.3 0 36.8-16.5 36.8-36.8c0-7.3-2.2-14.4-6.2-20.4L558.2 21.4C549.3 8 534.4 0 518.3 0H121.7c-16 0-31 8-39.9 21.4L6.2 134.7c-4 6.1-6.2 13.2-6.2 20.4C0 175.5 16.5 192 36.8 192zM64 224V384v80c0 26.5 21.5 48 48 48H336c26.5 0 48-21.5 48-48V384 224H320V384H128V224H64zm448 0V480c0 17.7 14.3 32 32 32s32-14.3 32-32V224H512z"
            />
          </svg>
          <span class="link-text">Retailers</span>
        </router-link>
      </li>
      <li class="nav-item login-out">
        <div>
          <router-link
            class="nav-link"
            v-bind:to="{ name: 'logout' }"
            v-if="$store.state.token != ''"
          >
            <svg
              class="nav-icon"
              xmlns="http://www.w3.org/2000/svg"
              height="1em"
              viewBox="0 0 512 512"
            >
              <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
              <path
                d="M406.5 399.6C387.4 352.9 341.5 320 288 320H224c-53.5 0-99.4 32.9-118.5 79.6C69.9 362.2 48 311.7 48 256C48 141.1 141.1 48 256 48s208 93.1 208 208c0 55.7-21.9 106.2-57.5 143.6zm-40.1 32.7C334.4 452.4 296.6 464 256 464s-78.4-11.6-110.5-31.7c7.3-36.7 39.7-64.3 78.5-64.3h64c38.8 0 71.2 27.6 78.5 64.3zM256 512A256 256 0 1 0 256 0a256 256 0 1 0 0 512zm0-272a40 40 0 1 1 0-80 40 40 0 1 1 0 80zm-88-40a88 88 0 1 0 176 0 88 88 0 1 0 -176 0z"
              />
            </svg>
          <span class="link-text">Logout</span>
          </router-link>
          <router-link v-bind:to="{ name: 'login' }" v-else class="nav-link">
            <svg
              class="nav-icon"
              xmlns="http://www.w3.org/2000/svg"
              height="1em"
              viewBox="0 0 512 512"
            >
              <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
              <path
                d="M399 384.2C376.9 345.8 335.4 320 288 320H224c-47.4 0-88.9 25.8-111 64.2c35.2 39.2 86.2 63.8 143 63.8s107.8-24.7 143-63.8zM0 256a256 256 0 1 1 512 0A256 256 0 1 1 0 256zm256 16a72 72 0 1 0 0-144 72 72 0 1 0 0 144z"
              />
            </svg>
          <span class="link-text">Login</span>
          </router-link>
        </div>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: "navBar",
};
</script>

<style>
</style>