 <template>
 <h4>{{ item.reviewer }}</h4>
      <div class="rating">
        <img
          src="../assets/star.png"
          v-bind:title="item.rating + ' Star Review'"
          class="ratingStar"
          v-for="n in item.rating"
          v-bind:key="n"
        />
      </div>

      <h3>{{ item.title }}</h3>
      <p>{{ item.review }}</p>
      <p>Favorite? <input type="checkbox" 
        v-model="item.favorited" /></p>
        </template>
        <script>

        export default {

            props: ["item"]
        }
        </script>