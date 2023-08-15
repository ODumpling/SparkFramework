<script setup>
import { computed } from 'vue'
import { Link, usePage, useForm } from '@inertiajs/vue3'
import { Menu, MenuButton, MenuItems, MenuItem } from '@headlessui/vue'

const page = usePage()
const auth = computed(() => page.props.auth)
const form = useForm({})

function submit() {
  form.post('/logout')
}
</script>

<template>
  <nav class="relative w-full max-w-6xl mx-auto">
    <div class="flex justify-between items-center">
      <ul>
        <li class="px-2 py-4">
          <Link href="/">
          <div class="inline-flex items-center">
            <img src="/images/logo.png" class="h-12 w-auto" alt="logo" />
            <h4 class="text-2xl font-bold text-gray-700 mx-2">Spark</h4>
          </div>
          </Link>
        </li>
      </ul>





      <div v-if="auth.isAuthenticated" class="flex-wrap items-center w-auto hidden md:flex space-x-4">
        <Menu as="div" class="relative ml-3">
          <MenuButton class="flex">
            <span class="sr-only">Open user menu</span>
            <span class="font-semibold text-sm p-2">{{ auth.user.name }}</span>
            <span class="inline-block h-8 w-8 overflow-hidden rounded-full bg-gray-100 shadow-md">
              <svg class="h-full w-full text-gray-300" fill="currentColor" viewBox="0 0 24 24">
                <path
                  d="M24 20.993V24H0v-2.996A14.977 14.977 0 0112.004 15c4.904 0 9.26 2.354 11.996 5.993zM16.002 8.999a4 4 0 11-8 0 4 4 0 018 0z" />
              </svg>
            </span>

          </MenuButton>
          <MenuItems
            class="absolute right-0 z-50 mt-2 w-48 origin-top-right shadow-2xl bg-white py-1 border border-gray-600">
            <MenuItem v-slot="{ active }">
            <Link href="/dashboard"
              class="block px-4 py-4 text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold"
              role="menuitem">Dashboard
            </Link>
            </MenuItem>
            <MenuItem v-slot="{ active }">
            <Link href="/Profile/edit"
              class="block px-4 py-4 text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold"
              role="menuitem">Account
            </Link>
            </MenuItem>
            <MenuItem>
            <Link href="/logout" method="post" as="button" type="button"
              class="block px-4 py-4 w-full text-left text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold">
            Logout
            </Link>
            </MenuItem>
          </MenuItems>
        </Menu>
      </div>
      <ul v-else class="flex-wrap items-center w-auto hidden md:flex space-x-4">
        <li class="px-2 py-4">
          <Link class="text-lg font-medium text-indigo-600 hover:text-indigo-700" href="/login">Login</Link>
        </li>
        <li class="px-2 py-4">
          <Link class="px-3 py-4 text-lg bg-indigo-600 hover:bg-indigo-700 text-white rounded-md font-medium"
            href="/register">Register
          </Link>
        </li>
      </ul>
      <div class="w-auto md:hidden">
        <button class="text-gray-600 hover:text-black hover:bg-gray-100 bg-transparent p-2">
          <svg class="w-6 h-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
            stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
          </svg>
          <svg class="w-6 h-6" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
            <path fill-rule="evenodd"
              d="M5.47 5.47a.75.75 0 011.06 0L12 10.94l5.47-5.47a.75.75 0 111.06 1.06L13.06 12l5.47 5.47a.75.75 0 11-1.06 1.06L12 13.06l-5.47 5.47a.75.75 0 01-1.06-1.06L10.94 12 5.47 6.53a.75.75 0 010-1.06z"
              clip-rule="evenodd" />
          </svg>
        </button>
      </div>
    </div>
    <div class="lg:hidden bg-white drop-shadow-lg z-50 mb-12" id="mobile-menu">
      <div v-if="auth.isAuthenticated" class="py-3 space-y-1 px-4 md:px-12">
        <Link class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/dashboard">
        Dashboard
        </Link>
        <a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium"
          href="/account">Account</a>
        <form @submit.prevent="submit">
          <button type="submit"
            class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 w-full text-left font-medium">
            Logout
          </button>
        </form>
        <p class="text-sm px-4 py-2 border-t">{{ auth.user.name }}</p>
      </div>
      <div v-else class="py-3 space-y-1 px-4 md:px-12">
        <a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/login">Login</a>
        <a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium"
          href="/register">Register</a>
      </div>
    </div>
  </nav>
</template>