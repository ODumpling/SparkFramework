<template>
  <section class="w-full sm:max-w-md mx-auto py-12 flex flex-col justify-center items-center">
    <Link href="/">
    <img src="/images/logo.png" class="h-20 w-auto" alt="logo" />
    </Link>
    <h1 class="text-center mt-6 text-center text-3xl font-bold tracking-tight text-black">
      Login to your account
    </h1>
    <form @submit.prevent="form.post('/login')"
      class="mt-6 flex flex-col py-8 px-4 sm:px-10 bg-white sm:mx-auto sm:w-full sm:max-w-md shadow-lg rounded-md">
      <div class="mb-1 text-red-500 text-sm">
        <ul>
          <li v-for="err in errors" v-text="err"></li>
        </ul>
      </div>
      <div>
        <label for="Email" class="block font-medium text-sm text-gray-700">Email address</label>
        <div class="mt-1">
          <input v-model="form.email" type="email" autocomplete="email"
            class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
        </div>
        <div v-if="errors.email" v-text="errors.email" class="mt-1 text-red-500 text-sm"></div>
      </div>
      <div class="mt-8">
        <label for="Password" class="block font-medium text-sm text-gray-700">Password</label>
        <div class="mt-1">
          <input v-model="form.password" type="password" autocomplete="current-password"
            class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
        </div>
        <div v-if="errors.password" v-text="errors.password" class="mt-1 text-red-500 text-sm"></div>
      </div>
      <div class="mt-8">
        <label for="RememberMe" class="inline-flex items-center">
          <input v-model="form.remember" type="checkbox"
            class="rounded border-gray-300 text-indigo-600 shadow-sm focus:ring-indigo-500">
          <span class="ml-2 text-sm text-gray-600">Remember me</span>
        </label>
      </div>
      <div class="mt-8 flex justify-end items-center">
        <Link href="/Register"
          class="underline text-sm text-gray-600 hover:text-gray-900 rounded-md focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
        Don't have an account? Sign up
        </Link>
        <button type="submit"
          class="inline-flex items-center px-4 py-2 bg-indigo-700 border border-transparent rounded-md font-semibold text-xs text-white uppercase tracking-widest hover:bg-gray-700 focus:bg-gray-700 active:bg-gray-900 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition ease-in-out duration-150 ml-3">
          Login
        </button>
      </div>
    </form>
  </section>
</template>

<script setup>
import { Link, useForm } from "@inertiajs/vue3";

const form = useForm({
  email: "",
  password: "",
  remember: false,
});

defineProps({
  errors: Object,
});
</script>
