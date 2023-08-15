<template>
  <div>
    <section class="w-full sm:max-w-md mx-auto py-16 flex flex-col justify-center items-center">
      <Link href="/">
        <img src="/images/logo.png" class="h-20 w-auto" alt="logo"/>
      </Link>
      <h1 class="text-center mt-6 text-center text-3xl font-bold tracking-tight text-black">
        Create your account
      </h1>
      <form  @submit.prevent="form.post('/register')"
            class="mt-8 flex flex-col py-8 px-4 sm:px-10 bg-white sm:mx-auto sm:w-full sm:max-w-md shadow-lg rounded-md">
        <div class="mb-1 text-red-500 text-sm">
          @Html.ValidationSummary()
        </div>
        <div>
          <label for="Name" class="block font-medium text-sm text-gray-700">Name</label>
          <div class="mt-1">
            <input v-model="form.name" type="text"
                   class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full"/>
          </div>
          <div class="mt-1 text-red-500 text-sm">
            @Html.ValidationMessageFor(m => m.Name)
          </div>
        </div>
        <div class="mt-8">
          <label for="Email" class="block font-medium text-sm text-gray-700">Email address</label>
          <div class="mt-1">
            <input v-model="form.email" type="email" autocomplete="email"
                   class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full"/>
          </div>
          <div class="mt-1 text-red-500 text-sm">
            @Html.ValidationMessageFor(m => m.Email)
          </div>
        </div>
        <div class="mt-8">
          <label for="Password" class="block font-medium text-sm text-gray-700">Password</label>
          <div class="mt-1">
            <input v-model="form.password" type="password" autocomplete="current-password"
                   class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full"/>
          </div>
          <div class="mt-1 text-red-500 text-sm">
            @Html.ValidationMessageFor(m => m.Password)
          </div>
        </div>
        <div class="mt-8">
          <label for="ConfirmPassword" class="block text-sm font-medium text-gray-700">Comfirm password</label>
          <div class="mt-1">
            <input v-model="form.confirmPassword" type="password" autocomplete="current-password"
                   class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full"/>
          </div>
          <div class="mt-1 text-red-300 text-sm">
            @Html.ValidationMessageFor(m => m.ConfirmPassword)
          </div>
        </div>
        <div class="mt-8 flex justify-end items-center">
          <Link href="/login"
             class="underline text-sm text-gray-600 hover:text-gray-900 rounded-md focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
            Already registered?
          </Link>
          <button type="submit"
                  class="inline-flex items-center px-4 py-2 bg-indigo-700 border border-transparent rounded-md font-semibold text-xs text-white uppercase tracking-widest hover:bg-gray-700 focus:bg-gray-700 active:bg-gray-900 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition ease-in-out duration-150 ml-3">
            Create account
          </button>
        </div>
      </form>
    </section>
  </div>
</template>

<script setup>
import {Link, useForm} from '@inertiajs/vue3'

const form = useForm({
  name: '',
  email: '',
  password: '',
  confirmPassword: '',
})


</script>
