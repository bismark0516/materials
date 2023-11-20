<template>
  <div class="main">
    <h2>Product Reviews {{ title }}</h2>
    <p class="description">{{ description }}</p>

    <div class="well-display">
      <div class="well">
        <span class="amount">{{ averageRating }}</span>
        Average Rating
      </div>

      <div class="well">
        <span class="amount"><!-- data binding goes here --></span>
        1 Star Review
      </div>

      <div class="well">
        <span class="amount"><!-- data binding goes here --></span>
        2 Star Review
      </div>

      <div class="well">
        <span class="amount">{{ numberOfThreeStarReviews }}</span>
        3 Star Review{{ numberOfThreeStarReviews === 1 ? "" : "s" }}
      </div>

      <div class="well">
        <span class="amount"><!-- data binding goes here --></span>
        4 Star Review
      </div>

      <div class="well">
        <span class="amount"><!-- data binding goes here --></span>
        5 Star Review
      </div>
    </div>

   <!-- <div class="review" 
        v-for="review in reviews" 
        v-bind:key="review.id">
        -->

    <div class="review" 
        v-bind:class="{ favorited: review.favorited }" 
        v-for="review in reviews" 
        v-bind:key="review.id">

      <h4>{{ review.reviewer }}</h4>
      <div class="rating">
        <img
          src="../assets/star.png"
          v-bind:title="review.rating + ' Star Review'"
          class="ratingStar"
          v-for="n in review.rating"
          v-bind:key="n"
        />
      </div>

      <h3>{{ review.title }}</h3>
      <p>{{ review.review }}</p>
      <p>Favorite? <input type="checkbox" 
        v-model="review.favorited" /></p>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProductReview",
  data: () => {
    return {
      title: "Head First Design Book",
      description:
        "A brain friendly guide to building extensible and maintainable object-oriented software.",
      reviews: [
        {
          id: 1000,
          reviewer: "R Pérez",
          title: "Approachable pattern guide",
          review:
            "I love the uncomplicated, informal narrative style. I highly recommend this text for anyone trying to understand Design Patterns in a super simple way.",
          rating: 3,
          favorited: false,
        },
        {
          id: 1001,
          reviewer: "John Fulton",
          title: "Approachable pattern guide Part II",
          review: "OK, I guess.",
          rating: 5,
          favorited: true,
        },
      ],
    };
  },
  computed: {
    averageRating() {
      if (this.reviews.length === 0) {
        return 0;
      }

      // Use reduce to get the total of all the ratings
      let sum = this.reviews.reduce((currentSum, review) => {
        return currentSum + review.rating;
      }, 0);

      // Divide by the number of reviews
      return sum / this.reviews.length;
    },

    numberOfThreeStarReviews() {
      const threeStarReviews = this.reviews.filter((review) => {
        return review.rating === 3;
      });
      return threeStarReviews.length;
    },
  },
};
</script>

<style scoped>
.main {
  margin: 1rem 0;
}

.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}

.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  padding: 0.25rem;
}
.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

.favorited {
  background-color: lightyellow;
}

.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

.rating img {
  height: 100%;
}

.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}
.review p {
  margin: 20px;
}

.review h3 {
  display: inline-block;
}

.review h4 {
  font-size: 1rem;
}

div.main div.review.favorited {
    background-color: lightyellow;
}
</style>