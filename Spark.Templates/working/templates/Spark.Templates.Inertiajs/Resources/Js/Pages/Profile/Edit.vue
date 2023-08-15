<template>
  <section class="mx-auto max-w-6xl mb-20">
    <h1 class="text-2xl text-gray-800 font-bold mb-4">
      Profile
    </h1>
    <article class="bg-white shadow rounded-lg w-full my-12 p-6">
      <h2 class="text-xl font-medium mb-2">
        Profile Information
      </h2>
      <p class="text-gray-600">
        Update your account's profile information.
      </p>
      <form asp-action="Update" asp-controller="Profile" method="post" class="max-w-2xl flex flex-col space-y-6">
        <div class="mt-6">
          <label for="Name" class="block font-medium text-sm text-gray-700">Name</label>
          <div class="mt-1">
            <input v-model="profileForm.name" required
              class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
          </div>
          <div v-if="errors.name" v-text="errors.name" class="mt-1 text-red-500 text-sm"></div>
        </div>
        <div>
          <label for="Email" class="block font-medium text-sm text-gray-700">Email address</label>
          <div class="mt-1">
            <input v-model="profileForm.email" required type="email"
              class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
          </div>
          <div v-if="errors.email" v-text="errors.email" class="mt-1 text-red-500 text-sm"></div>
        </div>
        <div>
          <button type="submit"
            class="text-left px-4 py-2 bg-indigo-700 hover:bg-indigo-800 rounded-md font-semibold text-xs text-white uppercase tracking-widest focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition">
            Save
          </button>
        </div>
      </form>
    </article>
    <article class="bg-white shadow rounded-lg w-full my-12 p-6">
      <h2 class="text-xl font-medium mb-2">
        Update Password
      </h2>
      <p class="text-gray-600">
        Update your accounts current password.
      </p>
      <form class="max-w-2xl flex flex-col space-y-6">
        <div class="mt-6">
          <label for="CurrentPassword" class="block font-medium text-sm text-gray-700">Current Password</label>
          <div class="mt-1">
            <input v-model="passwordForm.currentPassword" type="password" required
              class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
          </div>
          <div v-if="errors.currentPassword" v-text="errors.currentPassword" class="mt-1 text-red-500 text-sm"></div>
        </div>
        <div>
          <label for="NewPassword" class="block font-medium text-sm text-gray-700">New Password</label>
          <div class="mt-1">
            <input v-model="passwordForm.newPassword" type="password" required
              class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
          </div>
          <div v-if="errors.newPassword" v-text="errors.newPassword" class="mt-1 text-red-500 text-sm"></div>
        </div>
        <div>
          <label for="ConfirmPassword" class="block font-medium text-sm text-gray-700">Confirm Password</label>
          <div class="mt-1">
            <input v-model="passwordForm.confirmPassword" type="password" required
              class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
          </div>
          <div v-if="errors.confirmPassword" v-text="errors.confirmPassword" class="mt-1 text-red-500 text-sm"></div>
        </div>
        <div>
          <button type="submit"
            class="text-left px-4 py-2 bg-indigo-700 hover:bg-indigo-800 rounded-md font-semibold text-xs text-white uppercase tracking-widest focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition">
            Save
          </button>
        </div>
      </form>
    </article>
  </section>
</template>

<script setup>
import { useForm } from '@inertiajs/vue3'

const props = defineProps({
  auth: Object,
  errors: Object,
});

const profileForm = useForm({
  name: props.auth.user.name,
  email: props.auth.user.email,
});

const passwordForm = useForm({
  currentPassword: '',
  newPassword: '',
  confirmPassword: '',
});

</script>