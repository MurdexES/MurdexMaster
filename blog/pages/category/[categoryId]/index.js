import { useRouter } from 'next/router';
import Link from 'next/link';
import { categories, posts } from '@/pages/data';

export default function CategoryPage() {
  const { query } = useRouter();
  const { categoryId } = query;

  const categoryPosts = posts[categoryId] || null;

  if (!categoryPosts) {
    return <h1>Category not found</h1>;
  }

  return (
    <div className="flex flex-col items-center px-10 py-8">
      <h1 className='text-2xl font-bold mb-12'>Category: <span className='text-green-500'>{categoryId}</span></h1>
      
      <ul className="text-lg text-center">
        {categoryPosts.map((post) => (
          <li key={post.id}>
            <Link href={`/category/${categoryId}/post/${post.id}`} className="hover:underline hover:text-green-500">
              {post.title}
            </Link>
          </li>
        ))}
      </ul>
      
      <Link href="/" className="hover:underline hover:text-green-500 mt-10" >Home</Link>
    </div>
  );
}
